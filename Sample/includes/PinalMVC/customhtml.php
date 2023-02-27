<?php
// Load Vars
$pmvc_custom_css = array();// Array custom for link: array( 'href' => 'URL to css', rel => 'stylesheet' )
$pmvc_custom_script = array();// Array custom for script: array( 'src' => 'URL to script' )
$pmvc_custom_head = "";// String custom for head: <style>...</style><meta...>
$pmvc_custom_body = "";// String custom for body: <script>...</script>

/*
 * Generate custom head
 */
function pmvcHead(){
	global $pmvc_custom_head;
	global $pmvc_custom_css;

	if(count($pmvc_custom_css) > 0){
		foreach($pmvc_custom_css as $item){
			?><link<?php
			foreach ($item as $key => $value) {
				echo " ".$key."='".$value."'";
			}
			?>></link> <?php
		}
	}

	echo $pmvc_custom_head;
}

/*
 * Generate custom body
 */
function pmvcBody(){
	global $pmvc_custom_body;
	global $pmvc_custom_script;

	if(count($pmvc_custom_script) > 0){
		foreach($pmvc_custom_script as $item){
			?><script<?php
			foreach ($item as $key => $value) {
				echo " ".$key."='".$value."'";
			}
			?>></script> <?php
		}
	}

	echo $pmvc_custom_body;
}

/*
 * Insert custom file css
 * $customArray: array custom array( 'href' => 'URL to css', rel => 'stylesheet' )
 */
function pmvcCSS($customArray){
	global $pmvc_custom_css;

	array_push($pmvc_custom_css, $customArray);
}

/*
 * Insert custom file script
 * $customArray: array custom array( 'src' => 'URL to script' )
 */
function pmvcScript($customArray){
	global $pmvc_custom_script;

	array_push($pmvc_custom_script, $customArray);
}
?>