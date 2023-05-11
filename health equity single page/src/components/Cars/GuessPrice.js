import React, {useState} from "react";
import "./GuessPrice.css";

const GuessPrice= (props) => {
  const [priceGuessed,setPriceGuessed] = useState(0);
  
  const priceChangeHandler = (event) => {
    setPriceGuessed(event.target.value);

  };

  const onGuessPriceHandler = (event) => {
    props.onGuessPriceHandler(priceGuessed);

  };
  

  return (
      <div>
        <input type="number" min={0} max={1000000000} value={priceGuessed} onChange={priceChangeHandler} className="guess-price-input"/>
        <button onClick={onGuessPriceHandler}>Guess Price</button>               
      </div>
  );
}

export default GuessPrice;
