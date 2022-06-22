import React, { useState, useEffect } from 'react';
import '../static/style.css';
import { Link } from 'react-router-dom';


export default function Home() {

  const [forecasts, setData] = useState([]);;

  const populateuserData = async () => {

    try {
      const response = await fetch('weatherforecast', { redirect: 'error' });
      const data = await response.json();
      console.log(data);
      setData(data);
    }
    catch
    {
      this.setData({
        forecasts: [{ date: 'Unable to get weather forecast' }],
        loading: false
      });
    }
  }


  useEffect(() => {
    populateuserData();
  }, []);



  return (
    <>
      
        {/* <button onClick={this.func} className='btn btn-primary'>mybutton</button> */}


        <div className='row mt-4'>

          <div className='col'>

           


            {forecasts.map(forecast =>
              
                <Link key={forecast.name} to={'Ui/Fetchdata/' + forecast.id} activeClassName="active">
                  <img key={forecast.name} src={require('../static/images/' + forecast.movie_Poster_Path).default} alt={"demo"} />

                </Link>
              
             
            )}

        

          </div>

        </div>
      
    </>
  );
}