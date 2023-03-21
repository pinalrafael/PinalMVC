<?php
// Include the main lib
include('includes/PinalMVC/main.php');
// Include the html custom
include('includes/PinalMVC/customhtml.php');
// Include the routes custom
include('includes/PinalMVC/customroutes.php');

// Configure folder root
pmvcSetRoot("/PinalMVC/");

// Configure route custom for controller
pmvcCustomRoutes(array( 'type' => 'C', 
'original' => 'CustomControllerRoute', 
'custom' => 'custom_controller' ));

// Configure route custom for function
pmvcCustomRoutes(array( 'type' => 'F', 
'original' => 'CustomFunctionRoute', 
'custom' => 'custom_function' ));

// Configure route custom for id
pmvcCustomRoutes(array( 'type' => 'I', 
'original' => '0123456789', 
'custom' => 'custom_id' ));

// Configure route custom for function with params
pmvcCustomRoutes(array( 'type' => 'F', 
'original' => 'CustomFunctionRouteParams', 
'custom' => 'custom_function_params',
'params' => array(0, 1, 2, 3, 4)));

// Include the setup lib
include('includes/PinalMVC/setup.php');

?>
