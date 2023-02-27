<?php

$pmvc_title = "CustomControllerRoute";
$pmvc_Model = new CustomControllerRoute();

if(pmvcGetValueFunction() == "Index"){
	if(isset($_GET)){
		
	} else if(isset($_POST)){
	
	}
}else{
	pmvcView("PagesErrors", "Error404", array('msg' => 'Function not found'));
}

?>