<?php
	include 'connectDB.php';

	$PYID = $_POST['PYID'];
    $ans = array();
    $data = array();

    $sql = "select * from TABLE_PLAYER as t1,TABLE_HISTORY as t2 where t1.PLAYER_ID = '".$PYID."' and t1.PLAYER_ID = t2.PLAYER_ID";
    $result = $con->query($sql);
    $row = $result->fetch_assoc();

    if($row){
        $data['PID'] = $row['PET_ID'];
        $data['START_DATE'] = $row['START_DATE'];
        $data['PET_NAME'] = $row['PET_NAME'];
        $data['PET_WEIGHT'] = $row['PET_WEIGHT'];
        $data['PET_FOOD'] = $row['PET_FOOD'];
        $data['UPDATE_DATE'] = $row['UPDATE_DATE'];
        $data['PET_TOTALTIME'] = $row['PET_TOTALTIME'];
        $ans['TYPE'] = "DATA";
        $ans['VALUE'] = $data;
	}
    else{
        $ans['TYPE'] = "ERROR";
        $ans['VALUE'] = "dont_have_data";
    }

    echo json_encode($ans);
?>