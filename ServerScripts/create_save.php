<?php

$name=$_GET['name'];

$fp = fopen($name."transpose.csv", 'w'); 
$list = array( 
    ['Puzzle 1'], 
    ['Puzzle 2'], 
    ['Puzzle 3'], 
    ['Puzzle 4'],
    ['Puzzle 5'], 
); 
  
foreach ($list as $fields) { 
    fputcsv($fp, $fields); 
} 

  
fclose($fp); 


$fp = fopen($name."rowop.csv", 'w'); 
$list = array( 
    ['Puzzle 1'], 
    ['Puzzle 2'], 
    ['Puzzle 3'], 
    ['Puzzle 4'],
    ['Puzzle 5'], 
    ['Puzzle 6'],
); 
   
foreach ($list as $fields) { 
    fputcsv($fp, $fields); 
} 

  
fclose($fp); 

?>