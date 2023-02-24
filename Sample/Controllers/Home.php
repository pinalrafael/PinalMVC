<?php

$pmvc_title = "Home";
$pmvc_Model = new Home();

if(pmvcGetValueFunction() == "Index"){
	if(isset($_GET)){
		$msg = $pmvc_Model->getMsg();
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "NewFunction"){
	if(isset($_GET)){
		$msg = "NewFunction";

		pmvcView("Home", "Index");
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "Arguments"){
	if(isset($_GET)){
		$msg = $pmvc_args["arg0"]." - ".$pmvc_args["arg1"]." - ".$pmvc_args["arg2"]." - ".$pmvc_args["arg3"];

		pmvcView("Home", "Index");
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "Parameters"){
	if(isset($_GET)){
		$msg = $_GET["par0"]." - ".$_GET["par1"]." - ".$_GET["par2"]." - ".$_GET["custompar"];

		pmvcView("Home", "Index");
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "CustomScript"){
	if(isset($_GET)){
		$pmvc_custom_body = "<script>alert('Custom Script'); </script>";

		pmvcView("Home", "Index");
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "CustomHead"){
	if(isset($_GET)){
		$pmvc_custom_head = "<style>.csscustom{ color: red; } </style>";

		$msg = "<p class='csscustom'>CustomHead Color</p>";

		pmvcView("Home", "Index");
	} else if(isset($_POST)){
	
	}
}else if(pmvcGetValueFunction() == "CustomBootstrap"){
	if(isset($_GET)){
		pmvcCSS(array( 'href' => 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/css/bootstrap.min.css', 
		'rel' => 'stylesheet', 
		'integrity' => 'sha384-GLhlTQ8iRABdZLl6O3oVMWSktQOp6b7In1Zl3/Jr59b6EGGoI1aFkw7cmDA6j6gD', 
		'crossorigin' => 'anonymous' ));

		pmvcScript(array( 'src' => 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.bundle.min.js',
		'integrity' => 'sha384-w76AqPfDkMBDXo30jS1Sgez6pr3x5MlQ1ZAGC+nuZB+EYdgRZgiwxhTBTkF7CXvN', 
		'crossorigin' => 'anonymous' ));

		pmvcScript(array( 'src' => 'https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.6/dist/umd/popper.min.js',
		'integrity' => 'sha384-oBqDVmMz9ATKxIep9tiCxS/Z9fNfEXiDAYTujMAeBAsjFuCZSmKbSSUnQlmh/jp3', 
		'crossorigin' => 'anonymous' ));

		pmvcScript(array( 'src' => 'https://cdn.jsdelivr.net/npm/bootstrap@5.3.0-alpha1/dist/js/bootstrap.min.js',
		'integrity' => 'sha384-mQ93GR66B00ZXjt0YO5KlohRA5SY2XofN4zfuZxLkoj1gXtW8ANNCe9d5Y3eG5eD', 
		'crossorigin' => 'anonymous' ));

		$msg = "<div id='liveAlertPlaceholder'></div>
				<button type='button' class='btn btn-primary' id='liveAlertBtn'>Show live alert</button>";

		$pmvc_custom_body = "<script>
			const alertPlaceholder = document.getElementById('liveAlertPlaceholder')

			const alert = () => {
			  const wrapper = document.createElement('div')
			  wrapper.innerHTML = [
				'<div class=\"alert alert-success alert-dismissible\" role=\"alert\">',
				'   <div>Nice, you triggered this alert message!</div>',
				'   <button type=\"button\" class=\"btn-close\" data-bs-dismiss=\"alert\" aria-label=\"Close\"></button>',
				'</div>'
			  ].join('')

			  alertPlaceholder.append(wrapper)
			}

			const alertTrigger = document.getElementById('liveAlertBtn')
			if (alertTrigger) {
			  alertTrigger.addEventListener('click', () => {
				alert()
			  })
			}
		</script>";

		pmvcView("Home", "Index");
	} else if(isset($_POST)){
	
	}
}else{
	pmvcView("PagesErrors", "Error404", array('msg' => 'Function '.pmvcGetValueFunction().' not found'));
}

?>