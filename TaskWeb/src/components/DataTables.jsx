import React, {Component} from 'react'

const signalR = require("@aspnet/signalr");
const $ = require('jquery')
$.DataTables = require('datatables.net')

class DataTables extends Component{
    constructor(){
        super()
    }

    componentDidMount(){
        
        this.interval = setInterval(() => this.setState(()=>{ fetch("https://localhost:5001/api/v1/beats")
        .then(response => response.json())
        .then(jsonData=>{this.renderTable(jsonData)});}), 1000); 
        
        
        
        //fetch("https://192.168.1.14:5001/api/v1/beats")
        //.then(response => response.json())
        //.then(jsonData=>{this.renderTable(jsonData)});
        //
        //let hubConnection = new signalR.HubConnectionBuilder()
        //                        .withUrl("https://192.168.1.14:5001/dataTables")                               
        //                        .build();
//
        //this.setState({ hubConnection}, () => {
        //    this.state.hubConnection
        //      .start().catch(()=>{})
        //      //.then(() => console.log('Connected!'))
        //      //.catch(err => console.log('Error on Connection'));
      //
        //    this.state.hubConnection.on('sendDataTables', (data) => {
        //        this.renderTable(data)
        //    });
        //});
        
    }

    renderTable(jsonData){
        this.$el = $(this.el)
        this.$el.DataTable( {
            order: [[ 2, "desc" ]],
            destroy: true,
            data: jsonData,
            lengthChange: false,
            searching:false,
            paging: false,
            info:false,
            columns: [
                { title: "Id", data: "id", width:"10%"},
                { title: "User Name", data: "beaterId"},
                { title: "Price", data: "price" },
                { title: "Beat time", data: "beatTime", render: function(row, index){
                    var date = new Date(row);
                    return date.toLocaleDateString()+" "+date.toLocaleTimeString();
                }
                },                
            ]
        });

    }

    componentWillUnmount(){
        clearInterval(this.interval);
        this.$el.DataTable.destroy(true);
    }
    render(){
        
        return (
            <div>
                <table id="mainTable" className="table table-striped table-bordered" width="100%" ref={el => this.el = el} ></table>
            </div>
        )
    }
}

export default DataTables

