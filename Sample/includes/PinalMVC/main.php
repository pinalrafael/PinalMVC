<?php
/*
 * CREATOR: RAFAEL PINAL
 * CREATED: 24/02/2023
 * UPDATED: 19/04/2023
 */

// Init System
$pmvc_dir = realpath(dirname(__FILE__));

// Load Config
$pmvc_config_json = file_get_contents($pmvc_dir."/config.json");
$pmvc_config = json_decode($pmvc_config_json);

// Load Vars
$pmvc_version = "1.5.0";// Lib version
$pmvc_root = $pmvc_config->root;// Folder root of index.php
$pmvc_title = $pmvc_config->name; // Title of page.
$pmvc_pars = array();// Array of URL paramters: URL?par0=p0&par1=p1&par2=p2&par3p3
$pmvc_APIRequest = json_decode(file_get_contents('php://input'), true);// POST request in API: $pmvc_APIRequest["key"]
$pmvc_Headers = apache_request_headers();// HTTP headersa
$pmvc_APIMethod = $_SERVER['REQUEST_METHOD'];// Request method

// Load system arguments
$pmvc_args = pmvcGetSysArgs($_GET);// Array of arguments: URL/arg0/arg1/arg2/arg3/

/* 
 * Set view custom for function
 * $controller: Controller of function
 * $function: Function of view
 */
function pmvcView($controller, $function, $pars = array()){
	global $pmvc_config;
	global $pmvc_view;
	global $pmvc_pars;

	$pmvc_pars = $pars;

	$pmvc_view = $pmvc_config->views.$controller.'/'.$function.$pmvc_config->views_suffix.'.php';
}

/*
 * Set folder root
 * $root: Folder, default is /
 */
function pmvcSetRoot($root){
	global $pmvc_root;

	$pmvc_root = $root;
}

/*
 * Get System arguments
 * $request: $_GET["request"]
 * return: Array system arguments
 */
function pmvcGetSysArgs($request){
	// Load MVC URL
	$pmvc_args = array( 'controller' => '', 'function' => '', 'id' => '' );
	if(isset($request['request'])){
		$pmvc_request = explode("/", $request['request']);
		if(count($pmvc_request) >= 1){
			$pmvc_args["controller"] = $pmvc_request[0];
		}
		if(count($pmvc_request) >= 2){
			$pmvc_args["function"] = $pmvc_request[1];
		}
		if(count($pmvc_request) >= 3){
			$pmvc_args["id"] = $pmvc_request[2];
		}

		// Load infinite URL
		if(count($pmvc_request) >= 4){
			$pmvc_par = 0;
			$pmvc_par_index = 3;
			for($pmvc_par_index; $pmvc_par_index < count($pmvc_request); $pmvc_par_index++, $pmvc_par++){
				$pmvc_args["arg".$pmvc_par] = $pmvc_request[$pmvc_par_index];
			}
		}
	}

	return $pmvc_args;
}

/*
 * Get the value of controller
 * return: Value of Controller
 */
function pmvcGetValueController(){
	global $pmvc_args;
	global $pmvc_custom_routes;
	global $pmvc_custom_routes_pars;

	if(count($pmvc_custom_routes) > 0){
		foreach($pmvc_custom_routes as $item){
			if($item['type'] == 'C'){
				if($item['custom'] == $pmvc_args["controller"]){
					$pmvc_args["controller"] = $item['original'];
					if(isset($item['params'])){
						$pmvc_custom_routes_pars = $item['params'];
					}
					break;
				}
			}
		}
	}

	return $pmvc_args["controller"] == '' ? 'Home' : $pmvc_args["controller"];
}

/*
 * Get the value of function
 * return: Value of function
 */
function pmvcGetValueFunction(){
	global $pmvc_args;
	global $pmvc_custom_routes;
	global $pmvc_custom_routes_pars;

	if(count($pmvc_custom_routes) > 0){
		foreach($pmvc_custom_routes as $item){
			if($item['type'] == 'F'){
				if($item['custom'] == $pmvc_args["function"]){
					$pmvc_args["function"] = $item['original'];
					if(isset($item['params'])){
						$pmvc_custom_routes_pars = $item['params'];
					}
					break;
				}
			}
		}
	}

	return $pmvc_args["function"] == '' ? 'Index' : $pmvc_args["function"];
}

/*
 * Get the value of id
 * return: Value of id
 */
function pmvcGetValueId(){
	global $pmvc_args;
	global $pmvc_custom_routes;
	global $pmvc_custom_routes_pars;

	if(count($pmvc_custom_routes) > 0){
		foreach($pmvc_custom_routes as $item){
			if($item['type'] == 'I'){
				if($item['custom'] == $pmvc_args["id"]){
					$pmvc_args["id"] = $item['original'];
					if(isset($item['params'])){
						$pmvc_custom_routes_pars = $item['params'];
					}
					break;
				}
			}
		}
	}

	return $pmvc_args["id"] == '' ? '0' : $pmvc_args["id"];
}

/*
 * Get the URL of model
 * return: Models/nameofmodel.class.php
 */
function pmvcGetURLModel(){
	global $pmvc_config;
	global $pmvc_args;

	$arg_controller = pmvcGetValueController();

	return $pmvc_config->models.$arg_controller.$pmvc_config->models_suffix.'.php';
}

/*
 * Get the URL of view
 * return: Views/nameofcontroller/nameoffunction.php
 */
function pmvcGetURLView(){
	global $pmvc_config;
	global $pmvc_args;

	$arg_controller = pmvcGetValueController();
	$arg_function = pmvcGetValueFunction();

	return $pmvc_config->views.$arg_controller.'/'.$arg_function.$pmvc_config->views_suffix.'.php';
}

/*
 * Get the URL of controller
 * return: Controllers/nameofcontroller.php
 */
function pmvcGetURLController(){
	global $pmvc_config;
	global $pmvc_args;

	$arg_controller = pmvcGetValueController();

	return $pmvc_config->controllers.$arg_controller.$pmvc_config->controllers_suffix.'.php';
}

/*
 * Execute POST, GET, PUT, DELETE... int API
 * $method: Method your request
 * $url: URL your request
 * $data (Optional): Data to send API array('key1' => 'value1', 'key2' => 'value2'), false when not sending data
 * $headers (Optional): Array custom header array('Authorization:9876543210', 'APIKey: 1234567890')
 * return: Json return your API
 */
function pmvcCallAPI($method, $url, $data = false, $headers = array()){
   $curl = curl_init();
   switch ($method){
      case "POST":
         curl_setopt($curl, CURLOPT_POST, 1);
         if ($data)
            curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($data));
         break;
      case "PUT":
         curl_setopt($curl, CURLOPT_PUT, 1);
         if ($data)
            curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($data));					
         break;
	  case "DELETE":
         curl_setopt($curl, CURLOPT_CUSTOMREQUEST, "DELETE");
         if ($data)
            curl_setopt($curl, CURLOPT_POSTFIELDS, json_encode($data));			 					
         break;
      default:
         if ($data)
            $url = sprintf("%s?%s", $url, http_build_query(json_encode($data)));
   }
   // OPTIONS:
   curl_setopt($curl, CURLOPT_URL, $url);

   if(!isset($headers)){
	   $headers = array('Content-Type: application/json');
   }else{
	   foreach ($headers as $head) { 
		   if(strpos(strtolower($head), strtolower('Content-Type')) !== true){
			   array_push($headers, 'Content-Type: application/json');
			   break;
		   }
	   }
   }

   curl_setopt($curl, CURLOPT_HTTPHEADER, $headers);
   curl_setopt($curl, CURLOPT_RETURNTRANSFER, 1);
   curl_setopt($curl, CURLOPT_HTTPAUTH, CURLAUTH_BASIC);
   // EXECUTE:
   $result = curl_exec($curl);
   if(!$result){
	   $result = "Connection Failure";
   }
   curl_close($curl);
   return $result;
}
?>