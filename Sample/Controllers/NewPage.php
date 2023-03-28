<?php

$pmvc_layout = "Views/Layout/_Layout.php";
$pmvc_title = "NewPage";
$pmvc_Model = new NewPage();

function Index(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters

	if(isset($_POST)){
	}
}

function Create(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters

	if(isset($_POST)){
	}
}

function Update($id){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters

	$pmvc_Model->id = $id;
	$pmvc_Model->UpdateMSG();

	if(isset($_POST)){
	}
}

function Delete($id){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters

	$pmvc_Model->id = pmvcGetValueId();
	$pmvc_Model->UpdateMSG();

	if(isset($_POST)){
	}
}

?>