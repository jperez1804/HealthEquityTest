import React, { useState } from "react";
import Cars from "./components/Cars/Cars";

const DUMMY_CARS = [
  {
    id : 1, make : "Audi", model : "R8", Year : 2018, doors : 2, color : "Red", price : 20000
  },
  {
    id : 2, make : "Tesla", Model : "3", Year : 2018, doors : 4, color : "Black", price : 54995
  },
  { id : 3, make : "Porsche", model : " 911 991", Year : 2020, doors : 2, color : "White", price : 155000 },
  { id : 4, make : "Mercedes-Benz", model : "GLE 63S", Year : 2021, doors : 5, color : "Blue", price : 83995 },
  { id : 5, make : "BMW", model : "X6 M", Year : 2020, doors : 5, color : "Silver", price : 62995 }, 
];

const App = () => {
        
  return (
    <div>      
      <Cars items={DUMMY_CARS} />
    </div>
  );
};

export default App;

