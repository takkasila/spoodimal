 <?php
	include 'connectDB.php';

	$PYID = $_POST['PYID'];
	$PET_NAME = $_POST['PET_NAME'];
	$PET_WEIGHT = (double)$_POST['PET_WEIGHT'];
	$PET_FOOD = (int)$_POST['PET_FOOD'];
	$PET_TOTALTIME = (double)$_POST['PET_TOTALTIME'];

    $sql = "update TABLE_HISTORY set PET_NAME = '".$PET_NAME."',PET_WEIGHT = ".$PET_WEIGHT.",PET_FOOD = ".$PET_FOOD.",PET_TOTALTIME = ".$PET_TOTALTIME." where PLAYER_ID = '".$PYID."'";
    $con->query($sql);
?>