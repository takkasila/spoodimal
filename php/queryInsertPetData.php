 <?php
	include 'connectDB.php';

	$PYID = $_POST['PYID'];
	$PET_NAME = $_POST['PET_NAME'];
	$PET_WEIGHT = (double)$_POST['PET_WEIGHT'];

    $sql = "insert into TABLE_HISTORY(PLAYER_ID,PET_NAME,PET_WEIGHT) value('".$PYID."','".$PET_NAME."',".$PET_WEIGHT.")";
	$con->query($sql);
?>