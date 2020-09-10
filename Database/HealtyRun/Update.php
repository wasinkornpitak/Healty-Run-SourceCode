<?
// update data table player
include("Connect.php"); 
$Value_score = $_POST['Value_score'];
$Count_hp = $_POST['Count_hp'];
$Count_milk = $_POST['Count_milk'];
$Count_miniItem = $_POST['Count_miniItem'];
$Count_bigItem = $_POST['Count_bigItem'];
$Count_time = $_POST['Count_time'];
$Count_hpEnemy = $_POST['Count_hpEnemy'];
$Count_scoreEnemy = $_POST['Count_scoreEnemy'];
$Distance = $_POST['Distance'];
$UserName = $_POST['UserName'];
$Date_score = $_POST['Date_score'];

	$strSQL = "INSERT INTO score VALUES (null, '$Value_score', '$Count_hp', '$Count_milk', '$Count_miniItem ', '$Count_bigItem', '$Count_time', '$Count_hpEnemy', '$Count_scoreEnemy', '$Distance', '$Date_score','$UserName')";

		$result = mysql_query($strSQL);
		if($result){
			echo "Update Complete.";
		}else{
			echo "Update Error.";
		}