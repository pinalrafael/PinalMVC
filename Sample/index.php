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

// Include the setup lib
include('includes/PinalMVC/setup.php');

?>
<!DOCTYPE html>
<html lang="pt-BR">
	<head>
		<?php header('Content-Type: text/html; charset=iso-8859-1'); ?>
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
		<title>Site Test - <?php echo $pmvc_title; ?></title>

		<!-- PAGE HEADER TAGS -->

		<?php pmvcHead(); ?>
	</head>
	<body>
	Version: <?php echo $pmvc_version; ?><br>
	<a href="<?php echo $pmvc_root; ?>">Home</a> - <a href="<?php echo $pmvc_root; ?>NewPage">NewPage</a> - <a href="<?php echo $pmvc_root; ?>PageNotFound">PageNotFound</a> - <a href="<?php echo $pmvc_root; ?>custom_controller">CustomControllerRoute</a>
	<br>
	<?php require($pmvc_view); ?>

	<!-- PAGE SCRIPTS -->

	<?php pmvcBody(); ?>
	</body>
</html>
