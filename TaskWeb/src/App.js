import React, { Component } from 'react';
import BeatForm from './components/BeatForm'
import DataTables from './components/DataTables'

class App extends Component {
  render(){
    return ( 
      <div>
        <BeatForm />
        <DataTables />
      </div>
    )
  }
  
}

export default App;
