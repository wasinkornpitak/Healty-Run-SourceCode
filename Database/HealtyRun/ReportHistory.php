<?php

include("Connect.php");

	$data = array();
	$all_data = array();

	$UserName = $_POST['Id'];

	$sql="SELECT Value_score, Count_hp, Count_milk, Count_miniItem, Count_bigItem, Count_hpEnemy, Count_scoreEnemy, 
				 DATE_FORMAT(score.Date_score, '%d/%m/%Y %H:%i:%s' ) AS Date_score
		  FROM score 
		  WHERE UserName = '$UserName' 
		  ORDER BY Value_score DESC";

	$res = mysql_query($sql);
	while ($row = mysql_fetch_assoc($res)) {
		$data = array($row);
		$all_data = array_merge($all_data, $data);
	}

	$retrun["History"] = $all_data;
	echo json_encode($retrun);

?>