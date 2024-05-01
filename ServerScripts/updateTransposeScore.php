<?php
    $name = $_GET['name'];
    $puzzle = $_GET['puzzle'];
    $list = [];
    $i = 0;
    $csvData = fopen($name."transpose.csv", 'r');
    while (($row = fgetcsv($csvData)) !== false) 
    {
        $list[$i][] = $row[0];
        $list[$i][1] = $row[1];
        $i++;
    }

    fclose($csvData);
    
    if ($puzzle == "Puzzle1")
    {
        $list[0][1] = 'complete';
    }
    
    if ($puzzle == "Puzzle2")
    {
        $list[1][1] = 'complete';
    }
    
    if ($puzzle == "Puzzle3")
    {
        $list[2][1] = 'complete';
    }
    
    if ($puzzle == "Puzzle4")
    {
        $list[3][1] = 'complete';
    }
    
    if ($puzzle == "Puzzle5")
    {
        $list[4][1] = 'complete';
    }

    $fp = fopen($name."transpose.csv", 'w');
    foreach ($list as $fields) { 
        fputcsv($fp, $fields); 
    } 
    fclose($fp);
?>