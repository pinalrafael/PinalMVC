<?php

class NewPage{
	public $id;
	public $msg;

	function __construct(){
		$this->msg = "This is the NewPage";
	}

	function UpdateMsg(){
		$this->msg = "This is the ID:".$this->id;
	}
}

?>