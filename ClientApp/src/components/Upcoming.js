

import React, { useState, useEffect } from 'react';
import '../static/style.css';
import { Link } from 'react-router-dom';


export default function Upcoming() {

    const [forecasts, setData] = useState([]);;

    const populateuserData = async () => {

        try {
            const response = await fetch('weatherforecast', { redirect: 'error' });
            const data = await response.json();
            // console.log(data);
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
        <div className="fill-window">

            {/* <button onClick={this.func} className='btn btn-primary'>mybutton</button> */}


            <div className='row mt-4'>

                <div className='col'>
                    



                    {forecasts.filter(item =>
                        true === item.isUpcoming).map(filtereddata => (
                            <Link key={filtereddata.name} to={'Fetchdata/' + filtereddata.id} activeClassName="active">
                                <img key={filtereddata.name} src={require('../static/images/' + filtereddata.movie_Poster_Path).default} alt={"demo"} />
                            </Link>

                        ))}




                </div>

            </div>

        </div>
    );
}