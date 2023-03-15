<?php

$pmvc_layout = "Views/Layout/_Layout2.php";
$pmvc_title = "NewPage2";
$pmvc_Model = new NewPage2();

if(pmvcGetValueFunction() == "Index"){
	if(isset($_GET)){
		
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "Create"){
	if(isset($_GET)){
		
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "Update"){
	if(isset($_GET)){
		$pmvc_Model->id = pmvcGetValueId();
		$pmvc_Model->UpdateMSG();
	} else if(isset($_POST)){
		
	}
}else if(pmvcGetValueFunction() == "Delete"){
	if(isset($_GET)){
		$pmvc_Model->id = pmvcGetValueId();
		$pmvc_Model->UpdateMSG();
	} else if(isset($_POST)){
	
	}
}else{
	pmvcView("PagesErrors", "Error404", array('msg' => 'Function not found'));
}

?>