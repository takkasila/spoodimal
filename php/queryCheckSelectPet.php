<?php
	include 'connectDB.php';

	$UID = $_POST['UID'];

    $sql = "SELECT * FROM TABLE_PLAYER WHERE USER_ID = '".$UID."'";
    $result = $con->query($sql);
    $row = $result->fetch_assoc();
    if($row){
    	echo "selected";
	}
    else{
    	echo "not_selected";
    }
?>