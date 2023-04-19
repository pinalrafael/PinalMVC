<?php
// Get MVC files
$pmvc_model = pmvcGetURLModel();
$pmvc_view = pmvcGetURLView();
$pmvc_controller = pmvcGetURLController();
$pmvc_layout = "Views/Layout/_Layout.php";

// Check exists model and controller file
if(file_exists($pmvc_model)){
	include($pmvc_model);
}
if(file_exists($pmvc_controller)){
	include($pmvc_controller);

	if(function_exists(pmvcGetValueFunction())){
		$pmvc_APIResult = call_user_func(pmvcGetValueFunction(), pmvcGetValueId());
		// Check if API
		if(isset($pmvc_APIResult)){
			echo json_encode($pmvc_APIResult);
			die();
		}
	}
}

// Check exists view file
if(!file_exists($pmvc_view)){
	$pmvc_view = $pmvc_config->page_errors.'Error404'.$pmvc_config->page_errors_suffix.'.php';
}

if(file_exists($pmvc_layout)){
	include($pmvc_layout);
}
?>