<?php
	include 'connectDB.php';

	$UID = $_POST['UID'];

	$sql = "SELECT * FROM TABLE_PET AS t1, TABLE_PLAYER AS t2 WHERE t1.PET_ID = t2.PET_ID and t2.USER_ID = ".$UID;
    $result = $con->query($sql);
    $row = $result->fetch_assoc();
    echo $row['PET_WEIGHT'];
?>