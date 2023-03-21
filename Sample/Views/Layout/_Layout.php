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
	<a href="<?php echo $pmvc_root; ?>">Home</a> - 
	<a href="<?php echo $pmvc_root; ?>NewPage">NewPage</a> - 
	<a href="<?php echo $pmvc_root; ?>PageNotFound">PageNotFound</a> - 
	<a href="<?php echo $pmvc_root; ?>custom_controller">CustomControllerRoute</a> - 
	<a href="<?php echo $pmvc_root; ?>NewPage2">New Page Layout 2</a>
	<br>
	<?php require($pmvc_view); ?>

	<!-- PAGE SCRIPTS -->

	<?php pmvcBody(); ?>
	</body>
</html>
