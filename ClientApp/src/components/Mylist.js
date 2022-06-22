
import React, { useState, useEffect } from 'react';
import '../static/style.css';
import { Link } from 'react-router-dom';
import axios from 'axios';


export default function Mylist() {

    const [forecasts, setData] = useState([]);;


    const [finalresult, setfinalresultData] = useState([]);;

    const populateuserData = async () => {

        try {
            const response = await fetch('weatherforecast', { redirect: 'error' });
            const data = await response.json();
            //  console.log(data);
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
        // eslint-disable-next-line
        populateuserData(); func()
    }, []);



    function func() {
        //alert("alert called");
        let url = 'https://localhost:44377/api/WeatherForecast'


        let username;

        //AXIOS GET REQUEST SCRIPT
        axios.get(url
            , {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).then(function (response) {

            username = response.data;
            // console.warn(username);

            url = 'https://localhost:44377/api/DCandidate/'



            axios.get(url
                , {
                    headers: {
                        'Content-Type': 'application/json'
                    }
                }
            ).then(function (response) {
                console.warn(username);
                //console.warn(response);

                let result = [] //STORES ID OF MOVIES OF CURRENT USER


                var items = response.data //gets you array
                for (var i = 0; i < items.length; i++) {

                    if (items[i].username === username) {
                        result.push(items[i].movieid);

                    }
                }

                setfinalresultData(result);
                console.log(result);


                //console.warn(result);
                //  console.warn(forecasts.length);

                //   let final = [];

                //   console.warn(forecasts);

                //   for (var j = 0; j < result.length; j++) { 

                //     for (var k = 0; k < forecasts.length; k++) { 

                //       console.warn(forecasts[k].id);

                //       if(forecasts[k].id === result[j])
                //       {
                //         final.push(forecasts[k]);
                //       }



                //     }

                // }
                // setfinalresultData(final);



            })



        })
            .catch(function (error) {
                console.log(error)
            })

    }



    return (
        <div className="fill-window">

            {/* <button onClick={this.func} className='btn btn-primary'>mybutton</button> */}


            <div className='row mt-4'>

                <div className='col'>
                    <h3 className="moviename"><b><i>My Personalised List</i></b></h3><br />
             

                    <>

                        {finalresult.map(movieid =>

                            forecasts.filter(item =>
                                item.id === movieid).map(filtereddata => (
                                    <Link key={filtereddata.name} to={'Fetchdata/' + filtereddata.id} activeClassName="active">
                                        <img key={filtereddata.name} src={require('../static/images/' + filtereddata.movie_Poster_Path).default} alt={"demo"} />
                                    </Link>

                                ))

                        )}


                    </>









                </div>
            </div>


        </div>
    );
}