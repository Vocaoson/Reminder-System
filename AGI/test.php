#!/usr/bin/php -q

<?php

require_once "phpagi.php";
require_once "DatabaseUtils.php";

$action_id = 1;
//get template_id from action_id
$template_id = 1;
$db = new DatabaseUtils("remindersystem1","localhost","root","123456");
$agi = new AGI();
$action_data = array();
$agi->verbose($argv[1]);
action_handle($action_id,$template_id);
//action_handle($action_id,$template_id);
//get list sentence from template
function template_handle($template_id){
    global $db, $agi;
    $sentences = $db->select('SELECT Sentence.Id, Step, `Type` FROM Template INNER JOIN Sentence ON Template.Id = Sentence.TemplateId WHERE Template.Id = ? ORDER BY Step ASC',array($template_id));
    foreach($sentences as $datas){
        foreach($datas as $key => $value){
            if($key === "Type"){
                if($value == 1){ // read
                    sentence_handle($datas['Id']);
                } else if($value == 2){//write
                    // listener press something
                    $agi->exec('WAIT 10');
                }
            }
        }
    }
}
function sentence_handle($sentence_id){
    global $db, $agi,$action_data;
    $rows = $db->select('SELECT SentenceId,DataType, DataStore FROM Template INNER JOIN Sentence ON Template.Id = Sentence.TemplateId INNER JOIN `Data` ON Sentence.Id = Data.SentenceId WHERE SentenceId = ?',array($sentence_id));
    foreach($rows as $datas){
        foreach($datas as $key => $value){
            if($key === "DataType"){
                if($value == 1){// text to speech
                    $agi->verbose($datas['DataStore']);
                } else if($value == 2){ // audio
                    $agi->verbose($datas['DataStore']);
                    //$agi->stream_file($datas['DataStore']);
                    $agi->exec('Playback',$datas['DataStore']);
                } else if($value == 3){//data
                    //$agi->verbose($action_data[$datas['DataStore']]);
			  $agi->verbose($action_data);
                }
            }
        }
    }
}
function action_handle($action_id,$template_id){
    global $db, $agi,$action_data;
    $rows = $db->select('SELECT * FROM `Action` WHERE Id = ?',array($action_id));
    foreach($rows as $datas){
        foreach($datas as $key => $value){
            if($key === "Type"){
                if($value == 1){ // call
                    template_handle($template_id);
                } else if($value == 2){ // Message
                }
            } else if($key == "Data"){
                // $action_data = json_decode($datas['Data']);
                // $agi->verbose($action_data);
                //$json = '{"Name":"Son","Age":13}';
                $action_data = json_decode($value,true);
            }
            
        }
    }
}

exit;



?>

