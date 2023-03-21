<?php
// Load Vars
$pmvc_custom_routes = array();// Array of custom routes
$pmvc_custom_routes_pars = array();// Array of custom routes parameters

/*
 * Configure custom routes
 * $customArray: array custom array( 'type' => 'C/F/I', 'original' => 'Create', 'custom' => 'new_person', 'params' => array() )
 * 'type': Type of route. C => Controller, F => Function, I => Id.
 * 'original': Route original of program.
 * 'custom': Route custom URL.
 * 'params': Array of parameters optionais.
 */
function pmvcCustomRoutes($customArray){
	global $pmvc_custom_routes;

	array_push($pmvc_custom_routes, $customArray);
}
?>