<?php

$pmvc_layout = "Views/Layout/_Layout.php";
$pmvc_title = "APICli";
$pmvc_Model = new APICli();

function Index(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_Headers;// HTTP headers

	if(isset($_POST)){
	}

	$data = pmvcCallAPI('GET', 'http://rafaelpinal.siteprofissional.com/PinalMVC/RouteAPI');
	$response = json_decode($data, true);

	$pmvc_Model->list = $response["data"];
}

function Create(){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_Headers;// HTTP headers

	if(isset($_POST)){
	}

	$data = pmvcCallAPI('POST', 'http://rafaelpinal.siteprofissional.com/PinalMVC/RouteAPI/Create', array('name' => 'Send By Client API'));
	$response = json_decode($data, true);

	$pmvc_Model->msg = $response["data"];
}

function Update($id){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_Headers;// HTTP headers

	if(isset($_POST)){
	}

	$data = pmvcCallAPI('PUT', 'http://rafaelpinal.siteprofissional.com/PinalMVC/RouteAPI/Update/'.$id);
	$response = json_decode($data, true);

	$pmvc_Model->msg = $response["data"];
}

function Delete($id){
	global $pmvc_title;// Title your page
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_head;// Custom head page
	global $pmvc_custom_body;// Custom head body
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_Headers;// HTTP headers

	if(isset($_POST)){
	}

	$data = pmvcCallAPI('DELETE', 'http://rafaelpinal.siteprofissional.com/PinalMVC/RouteAPI/Delete/'.$id, false, array('Authorization: 9876543210', 'APIKey: 1234567890'));
	$response = json_decode($data, true);

	$pmvc_Model->msg = "Authorization: ".$response["data"]["Authorization"]." APIKey: ".$response["data"]["Apikey"];
}

?>