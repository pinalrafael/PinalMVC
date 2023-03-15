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
}

// Check exists view file
if(!file_exists($pmvc_view)){
	$pmvc_view = $pmvc_config->page_errors.'Error404'.$pmvc_config->page_errors_suffix.'.php';
}

if(file_exists($pmvc_layout)){
	include($pmvc_layout);
}
?>