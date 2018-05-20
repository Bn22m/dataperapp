<?php

/*
 * Products.php
 */
include '../configs/dbconfig.php';

/**
 * Description of Products
 *
 * @author Brian
 */
class Products 
{
    var $name;
    var $code;
    var $quantity;
    var $price;
    var $discount;
    var $temp;
    
    function __construct($cde) 
    {
        $this->code = $cde;
        $this->discount = 0;
        $this->quantity = 0;
        $this->price = 0;
        $this->name = "";
    }
    
    function discountp($pprice)
    {
        if(($pprice >= 50) && ($pprice <= 100))
        {
            $this->discount = 0/100;
        }
        elseif (($pprice >= 112) && ($pprice <= 115)) 
        {
            $this->discount = 0.25/100;
        }
        elseif ($pprice > 120) 
        {
            $this->discount = 0.50/100;        
        }
        
        return $this->discount;
    }
    
    function quantityp($cde)
    {
        //echo "$cde";
        $this->temp = $cde;
        
        return $this->quantity;
    }
    
    
}
