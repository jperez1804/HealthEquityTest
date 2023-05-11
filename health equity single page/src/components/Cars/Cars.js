import React, { useState } from "react";
import "./Cars.css";

import Card from "../UI/Card";
import CarsList from "./CarsList";



const Cars = (props) => {
  
   return (
    <div>
      <Card className="cars">
        <CarsList items={props.items} />        
      </Card>
    </div>
  );
};

export default Cars;
