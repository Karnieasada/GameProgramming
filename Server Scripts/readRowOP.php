<?php
    $name=$_GET['name'];

    $csvData = fopen($name."rowop.csv", 'r');
    while (($row = fgetcsv($csvData)) !== false) 
    {
        echo $row[0].$row[1], "_";
    }
    fclose($csvData);
?>
