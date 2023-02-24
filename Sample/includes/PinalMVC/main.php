<?php
/*
 * CREATOR: RAFAEL PINAL
 * DATE: 24/02/2023
 */
// Load Vars
$pmvc_version = "1.0.0";// Lib version
$pmvc_root = "/";// Folder root of index.php
$pmvc_title = "Page Title"; // Title of page.
$pmvc_pars = array();// Array of URL paramters: URL?par0=p0&par1=p1&par2=p2&par3p3
$pmvc_custom_css = array();// Array custom for link: array( 'href' => 'URL to css', rel => 'stylesheet' )
$pmvc_custom_script = array();// Array custom for script: array( 'src' => 'URL to script' )
$pmvc_custom_head = "";// String custom for head: <style>...</style><meta...>
$pmvc_custom_body = "";// String custom for body: <script>...</script>

// Load system arguments
$pmvc_args = pmvcGetSysArgs($_GET['request']);// Array of arguments: URL/arg0/arg1/arg2/arg3/

// Get MVC files
$pmvc_model = pmvcGetURLModel();
$pmvc_view = pmvcGetURLView();
$pmvc_controller = pmvcGetURLController();

// Check exists model and controller file
if(file_exists($pmvc_model)){
	include($pmvc_model);
}
if(file_exists($pmvc_controller)){
	include($pmvc_controller);
}

// Check exists view file
if(!file_exists($pmvc_view)){
	$pmvc_model = 'Models/Error404.class.php';
	$pmvc_view = 'Views/PagesErrors/Error404.php';
	$pmvc_controller = 'Controllers/Error404.php';
}

/* 
 * Set view custom for function
 * $controller: Controller of function
 * $function: Function of view
 */
function pmvcView($controller, $function, $pars = array()){
	global $pmvc_view;
	global $pmvc_pars;
	$pmvc_pars = $pars;
	$pmvc_view = 'Views/'.$controller.'/'.$function.'.php';
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
	$pmvc_request = explode("/", $request);
	$pmvc_args["controller"] = $pmvc_request[0];
	$pmvc_args["function"] = $pmvc_request[1];
	$pmvc_args["id"] = $pmvc_request[2];

	// Load infinite URL
	$pmvc_par = 0;
	$pmvc_par_index = 3;
	for($pmvc_par_index; $pmvc_par_index < count($pmvc_request); $pmvc_par_index++, $pmvc_par++){
		$pmvc_args["arg".$pmvc_par] = $pmvc_request[$pmvc_par_index];
	}

	return $pmvc_args;
}

/*
 * Get the value of controller
 * return: Value of Controller
 */
function pmvcGetValueController(){
	global $pmvc_args;
	return $pmvc_args["controller"] == '' ? 'Home' : $pmvc_args["controller"];
}

/*
 * Get the value of function
 * return: Value of function
 */
function pmvcGetValueFunction(){
	global $pmvc_args;
	return $pmvc_args["function"] == '' ? 'Index' : $pmvc_args["function"];
}

/*
 * Get the value of id
 * return: Value of id
 */
function pmvcGetValueId(){
	global $pmvc_args;
	return $pmvc_args["id"] == '' ? '0' : $pmvc_args["id"];
}

/*
 * Get the URL of model
 * return: Models/nameofmodel.class.php
 */
function pmvcGetURLModel(){
	global $pmvc_args;
	$arg_controller = pmvcGetValueController();
	return 'Models/'.$arg_controller.'.class.php';
}

/*
 * Get the URL of view
 * return: Views/nameofcontroller/nameoffunction.php
 */
function pmvcGetURLView(){
	global $pmvc_args;
	$arg_controller = pmvcGetValueController();
	$arg_function = pmvcGetValueFunction();
	return 'Views/'.$arg_controller.'/'.$arg_function.'.php';
}

/*
 * Get the URL of controller
 * return: Controllers/nameofcontroller.php
 */
function pmvcGetURLController(){
	global $pmvc_args;
	$arg_controller = pmvcGetValueController();
	return 'Controllers/'.$arg_controller.'.php';
}

/*
 * Generate custom head
 */
function pmvcHead(){
	global $pmvc_custom_head;
	global $pmvc_custom_css;

	if(count($pmvc_custom_css) > 0){
		foreach($pmvc_custom_css as $item){
			?><link<?php
			foreach ($item as $key => $value) {
				echo " ".$key."='".$value."'";
			}
			?>></link> <?php
		}
	}

	echo $pmvc_custom_head;
}

/*
 * Generate custom body
 */
function pmvcBody(){
	global $pmvc_custom_body;
	global $pmvc_custom_script;

	if(count($pmvc_custom_script) > 0){
		foreach($pmvc_custom_script as $item){
			?><script<?php
			foreach ($item as $key => $value) {
				echo " ".$key."='".$value."'";
			}
			?>></script> <?php
		}
	}

	echo $pmvc_custom_body;
}

/*
 * Insert custom file css
 * $customArray: array custom array( 'href' => 'URL to css', rel => 'stylesheet' )
 */
function pmvcCSS($customArray){
	global $pmvc_custom_css;

	array_push($pmvc_custom_css, $customArray);
}

/*
 * Insert custom file script
 * $customArray: array custom array( 'src' => 'URL to script' )
 */
function pmvcScript($customArray){
	global $pmvc_custom_script;

	array_push($pmvc_custom_script, $customArray);
}
?>