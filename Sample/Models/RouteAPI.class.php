<?php

class RouteAPI{
	public $list;
	public $data;

	function __construct(){
		
	}

	function GET(){
		$this->list = array(
			array('id' => 1, 'name' => utf8_encode('Name Server API 1')),
			array('id' => 2, 'name' => utf8_encode('Name Server API 2'))
		);
	}
}

?>