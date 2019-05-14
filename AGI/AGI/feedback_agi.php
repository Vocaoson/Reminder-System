#!/usr/bin/php -q

<?php

require_once('DatabaseUtils.php');
require_once 'phpagi.php';

$agi = new AGI();
$agi->verbose('HELLO');

$db = new DatabaseUtils('calldetail', 'localhost', 'root', '123456');

$sql = "SELECT id, fb WHERE fb=:FB";
$params = array('FB' => $argv[1]);
$feedbackInfo = $db->select($sql, $params);

if($feedbackInfo != false) {
	$agi->set_variable('fb',$feedbackInfo[0]['fb']);
	
}

?>
