import React, {Component} from 'react'

const signalR = require("@aspnet/signalr");

class BeatForm extends Component{
    constructor(){
        super()
        this.state = {
            price: "0.00",
            beaterId: "Mr. Web",            
            editClass:"form-control",
            class:"",
            text:""            
        }
        this.sendPrice = this.sendPrice.bind(this);
        this.refreshValue = this.refreshValue.bind(this);
    };

    
    sendPrice(){
        var beat = JSON.stringify({
                beaterId: this.state.beaterId,
                price: parseFloat(this.state.price)
        })

        fetch("https://localhost:5001/api/v1/beats",
        {
            method: "POST",
            headers: {
                'Accept': 'application/json, text/plain',
                'Content-Type': 'application/json;charset=UTF-8'
            },
            body: beat
        })
    }

    refreshValue(event){
        this.setState({
            price : event.target.value
        })
    }

    keyDownHandle = (e) => {
        if (e.key === 'Enter') {            
            this.sendPrice()
        }
      }

    render(){
        return (
            // <form onSubmit={this.sendPrice}>             
            <div className="form-row">
                <div className="col-md-4 mb-3"></div>
                <div className="col-md-4 mb-3">
                    <label>Insert your price</label>
                    <div className="input-group">
                        <input type="number" onChange={this.refreshValue} onKeyDown={this.keyDownHandle} className={this.state.editClass} value={this.state.price} name="price" id="price" placeholder="0.00" step=".01" aria-describedby="basic-addon2" required />
                        <div className="input-group-append">
                            <input type="button" onClick={this.sendPrice} className="btn btn-outline-secondary" value="Beat price" />
                        </div>
                    </div>
                    
                    {/* <p className={this.state.class}>
                        {this.state.text}
                    </p> */}

                </div>
                <div className="col-md-4 mb-3"></div>
            </div>
            // </form>


        )
    }
}

export default BeatForm