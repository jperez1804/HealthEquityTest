import "./CarDetail.css";

const CarDetail= (props) => {
    
  return (
      <div className="car-detail">
        <div className="car-detailLabel">{props.detailLabel}</div>
        <div className="car-value">{props.detailValue}</div>        
      </div>
  );
}

export default CarDetail;
