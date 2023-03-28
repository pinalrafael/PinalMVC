<?php
$pmvc_layout = "Views/Layout/_Layout.php";
$pmvc_title = "Home";
$pmvc_Model = new Home();

function Index(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	if(isset($_POST)){
	}

	$msg = $pmvc_Model->getMsg();
}

function NewFunction(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$msg = "NewFunction";

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function Arguments(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$msg = $pmvc_args["arg0"]." - ".$pmvc_args["arg1"]." - ".$pmvc_args["arg2"]." - ".$pmvc_args["arg3"];

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function Parameters(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$msg = $_GET["par0"]." - ".$_GET["par1"]." - ".$_GET["par2"]." - ".$_GET["custompar"];

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function CustomScript(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters

	$pmvc_custom_body = "<script>alert('Custom Script'); </script>";

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function CustomHead(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$pmvc_custom_head = "<style>.csscustom{ color: red; } </style>";

	$msg = "<p class='csscustom'>CustomHead Color</p>";

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function CustomBootstrap(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	pmvcCSS(array( 'href' => 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css', 
		'rel' => 'stylesheet', 
		'integrity' => 'sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD', 
		'crossorigin' => 'anonymous' ));

	pmvcScript(array( 'src' => 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js',
		'integrity' => 'sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN', 
		'crossorigin' => 'anonymous' ));

	pmvcScript(array( 'src' => 'https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js',
		'integrity' => 'sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3', 
		'crossorigin' => 'anonymous' ));

	pmvcScript(array( 'src' => 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js',
		'integrity' => 'sha384-mQ93GR66B00ZXjt0YO5KlohRA5SY2XofN4zfuZxLkoj1gXtW8ANNCe9d5Y3eG5eD', 
		'crossorigin' => 'anonymous' ));

	$msg = "<div id='liveAlertPlaceholder'></div>
				<button type='button' class='btn btn-primary' id='liveAlertBtn'>Show live alert</button>";

	$pmvc_custom_body = "<script>
			const alertPlaceholder = document.getElementById('liveAlertPlaceholder')

			const alert = () => {
			  const wrapper = document.createElement('div')
			  wrapper.innerHTML = [
				'<div class=\"alert alert-success alert-dismissible\" role=\"alert\">',
				'   <div>Nice, you triggered this alert message!</div>',
				'   <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>',
				'</div>'
			  ].join('')

			  alertPlaceholder.append(wrapper)
			}

			const alertTrigger = document.getElementById('liveAlertBtn')
			if (alertTrigger) {
			  alertTrigger.addEventListener('click', () => {
				alert()
			  })
			}
		</script>";

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function CustomFunctionRoute(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$msg = "CustomFunctionRoute";

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function CustomIdRoute($id){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$pmvc_Model->id = $id;
	$msg = $pmvc_Model->UpdateMsg();

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function CustomFunctionRouteParams(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$msg = implode(" ",$pmvc_custom_routes_pars);

	if(isset($_POST)){
	}

	pmvcView("Home", "Index");
}

function Form(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $msg;

	$msg = "No name";

	if(isset($_POST["txtName"])){
		$msg = "Your name is: ".$_POST["txtName"];
	}
}

?>