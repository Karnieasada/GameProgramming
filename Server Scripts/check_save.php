<?php
    $name=$_GET['name'];

    $value = file_exists($name."transpose.csv");

    if ($value != NULL)
    {
        echo "found";
    }
    else
    {
        echo "no file";
    }
?>