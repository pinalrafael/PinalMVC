<?php
header('Content-Type: application/json');

$pmvc_Model = new RouteAPI();

function Index(){
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_APIRequest;// POST request in API
	global $pmvc_Headers;// HTTP headers
	global $pmvc_APIMethod;// Method request API

	$pmvc_Model->GET();

	return array('response' => true, 'data' => $pmvc_Model->list);
}

function Create(){
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_APIRequest;// POST request in API
	global $pmvc_Headers;// HTTP headers
	global $pmvc_APIMethod;// Method request API

	return array('response' => true, 'data' => $pmvc_APIRequest["name"]);
}

function Update($id){
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_APIRequest;// POST request in API
	global $pmvc_Headers;// HTTP headers
	global $pmvc_APIMethod;// Method request API

	return array('response' => true, 'data' => utf8_encode($pmvc_APIMethod." - Update ID:".$id));
}

function Delete($id){
	global $pmvc_Model;// Your object model
	global $pmvc_args;// MVC URL arguments
	global $pmvc_custom_routes_pars;// Custom route parameters
	global $pmvc_APIRequest;// POST request in API
	global $pmvc_Headers;// HTTP headers
	global $pmvc_APIMethod;// Method request API

	return array('response' => true, 'data' => $pmvc_Headers);
}

?>