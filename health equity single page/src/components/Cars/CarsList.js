import React from "react";
import "./CarsList.css";
import CarItem from "./CarItem";


const CarsList = props => {

  return <ul className="cars-list">
    {props.items.map((car) => (
      <CarItem
        key={car.id}
        make={car.make} 
        model={car.model}
        doors={car.doors}
        price={car.price}
        color={car.color}        
      />
    ))}
    </ul>;
};

export default CarsList;
