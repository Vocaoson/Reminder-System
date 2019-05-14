#!/usr/bin/php -q

<?php

require_once "phpagi.php";
$agi = new AGI();
$agi->answer();
$agi->exec("BackGround","beep&beep&beep");
$agi->say_number(123456);
$agi->say_digits(123456);
$agi->say_datetime();
exit;

?>
