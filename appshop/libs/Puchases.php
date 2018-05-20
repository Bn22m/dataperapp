<?php

/*
 * Purchase.php
 */
include '../configs/dbconfig.php';
/**
 * Description of Puchases
 *
 * @author Brian
 */
$app = new Puchases();
class Puchases 
{
    var $code;
    var $name;
    var $price;
    var $discount;
    var $dicountp;
    var $quantity;
    var $total;
    
    function __construct() 
    {
        $this->total = 0.00;
    }
    
    function sales()
    {
        try
        {
        include_once '../configs/dbconn.php';
        $mysqli = connDB();
        $query = "SELECT id name, code, price, discount,quantity FROM products";
        $smt = $mysqli->prepare($query);
        $smt->execute();
        $resultb = $smt->bind_result($this->code, $this->name, $this->price, $this->discount, $this->quantity);
        $y = 1;
        echo '<tr><td>Prod</td><td>Code</td><td>Price</td><td>Discount(%)</td><td>Total</td></tr>';
        while($smt->fetch())
        {
            $this->discounts($this->price);
            echo '<tr><td>'.$this->name.':</td>
            <td><input name="code'.$y.'" type="text" value="'.$this->code.'" readonly="true"/></td>
            <td><input name="price'.$y.'" type="text" value="'.$this->price.'" readonly="true"/></td>
            <td><input name="discount'.$y.'" type="text" value="'.$this->discount.'"readonly="true"/></td>
            <td><input name="total'.$y.'" type="text" value="'.$this->total.'"readonly="true"/></td>
            <td><input type="submit" name="buy'.$y.'" value="Buy'.$y.'"/></td>
            </tr>';
            //
            $y++;
        }
        $smt->close();
        $mysqli->close();
        } 
        catch (Exception $ex) 
        {

        }
    }
    
    function discounts($pricep)
    {
        $dsct = 0.00;
        try
        {
        include_once '../configs/dbconn.php';
        $mysqli = connDB();
        //
        $price = filter_var($pricep, FILTER_SANITIZE_STRIPPED);
        $pm = 120;
        $query = "SELECT discount FROM discounts WHERE  ($price > pmin and pmax is null) or ($price >= pmin and $price <= pmax)";
        $smt = $mysqli->prepare($query);
        $smt->execute();
        $smt->bind_result($dsct);
        $smt->fetch();
        $smt->close();
        $mysqli->close();
        if($dsct == "")
        {
            //echo "no disc <br>";
            $dsct = 0.00;
            //echo "$dsct <br> ";
        }
        $this->discount = $dsct;
        $this->dicountp = ($price * $dsct/100);
        $this->total = ($price - $this->dicountp);
        if($dsct > 0)
        {
            echo "$this->discount %<br> ";
            echo "$price - ";
            echo "$this->dicountp = ";
            echo "$this->total <br> ";
        }
        
        } 
        catch (Exception $ex)
        {

        }
    }
}
