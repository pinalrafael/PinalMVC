<?php
// Load Vars
$pmvc_custom_routes = array();// Array of custom routes

/*
 * Configure custom routes
 * $customArray: array custom array( 'type' => 'C/F/I', 'original' => 'Create', 'custom' => 'new_person' )
 * 'type': Type of route. C => Controller, F => Function, I => Id.
 * 'original': Route original of program.
 * 'custom': Route custom URL.
 */
function pmvcCustomRoutes($customArray){
	global $pmvc_custom_routes;

	array_push($pmvc_custom_routes, $customArray);
}
?>