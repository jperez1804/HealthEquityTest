import "./CarItem.css";
import CarDetail from "./CarDetail";
import GuessPrice from "./GuessPrice";
import Card from "../UI/Card";
import React, { useState } from "react";

const CarItem = (props) => {
  const onGuessPriceHandler = (priceGuessed) => {
    var diff = Math.abs(props.price - parseInt(priceGuessed));
    if (diff <= 5000) {
      alert("Great Job! :)");
    } else {
      alert("You didn't guess the price :(");
    }
  };

  return (
    <li>
      <Card className="car-item">
        <CarDetail detailLabel={"Doors"} detailValue={props.doors} />
        <CarDetail detailLabel={"Color"} detailValue={props.color} />
        <div className="car-item__description">
          <h2>
            {props.make} - {props.model}
          </h2>
        </div>
        <GuessPrice
          price={props.price}
          onGuessPriceHandler={onGuessPriceHandler}
        />
      </Card>
    </li>
  );
};

export default CarItem;
