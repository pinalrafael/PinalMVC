<?php

$pmvc_title = "NewPage";
$pmvc_Model = new NewPage();

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