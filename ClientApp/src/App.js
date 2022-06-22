import Home from './components/Home';
import Featured from './components/Featured';
import NavMenu from './components/NavMenu';
import Mylist from './components/Mylist';
import Newrelease from './components/Newrelease';
import Upcoming from './components/Upcoming';
import React from 'react'
import FetchData from './components/FetchData';


import {
  Switch,
  Route,
} from "react-router-dom";



export default function App() {


  return (
    <div>

      <NavMenu />

      <Switch>



        <Route exact path="/Home/Ui">
          <Home heading="Good job" />
        </Route>

        <Route  path="/Home/Ui/featured">
          <Featured />
        </Route>

        <Route path="/Home/Ui/Fetchdata">
          <FetchData />
        </Route>

        <Route  path="/Home/Ui/newrelease">
          <Newrelease />
        </Route>
        <Route  path="/Home/Ui/upcoming">
          <Upcoming heading="Good job" mode ="dark"/>
        </Route>
        <Route  path="/Home/Ui/mylist">
          <Mylist />
        </Route>
      </Switch>


    </div>
  );


}


