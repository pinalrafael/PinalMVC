<?php

class NewPage2{
	public $id;
	public $msg;

	function __construct(){
		$this->msg = "This is the NewPage2";
	}

	function UpdateMsg(){
		$this->msg = "This is the ID:".$this->id;
	}
}

?>