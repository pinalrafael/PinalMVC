<!DOCTYPE html>
<html lang="pt-BR">
	<head>
		<?php header('Content-Type: text/html; charset=iso-8859-1'); ?>
		<meta http-equiv="X-UA-Compatible" content="IE=edge">
		<meta name="viewport" content="width=device-width, initial-scale=1,maximum-scale=1,user-scalable=no">
		<title>Site Test 2 - _Layout2 - <?php echo $pmvc_title; ?></title>

		<!-- PAGE HEADER TAGS -->

		<?php pmvcHead(); ?>
	</head>
	<body>
	Version: <?php echo $pmvc_version; ?><br>
	<a href="<?php echo $pmvc_root; ?>">Home</a> 
	<br>
	<h1>Layout 2</h1>
	<?php require($pmvc_view); ?>

	<!-- PAGE SCRIPTS -->

	<?php pmvcBody(); ?>
	</body>
</html>
