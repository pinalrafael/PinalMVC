<?php

class Home{
	public $id;

	function __construct(){
		
	}

	function getMsg(){
		return "This is Home Page";
	}

	function UpdateMsg(){
		return "This is custom ID:".$this->id;
	}
}

?>