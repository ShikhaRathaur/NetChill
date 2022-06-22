import React, { useState, useEffect } from 'react';
import '../static/style.css';
import { Row, Col, Container, Card, Button } from 'react-bootstrap';
import axios from 'axios';


export default function FetchData() {

  const [forecasts, setData] = useState([]);

  let text = window.location.href;
  const video_names_array = text.split("/");
  let len = video_names_array.length;
  let index = video_names_array[len - 1];
  const val = parseInt(index);



  const [is_added, setStatus] = useState(false);

  const [is_freshReloaded, setreloadStatus] = useState(1);


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


  function func() 
  {
    // alert("sdd");
    let url = 'https://localhost:44377/api/WeatherForecast'

    let username;

    //GET REQUEST
    axios.get(url
      , {
        headers: {
          'Content-Type': 'application/json'
        }
      }
    ).then(function (response) {
                  username = response.data;
                  url = 'https://localhost:44377/api/DCandidate/'

                  var postdata = {
                    username: username,
                    movieid: val
                  };

                  //PUT REQUEST ON FIRST RELOAD CHECKING PREVIOUS STATE OF MOVIE :RETURNS BOOLEAN

                  if (is_freshReloaded === 1) 
                  {

                    axios.put(url+val, postdata
                      , {
                        headers: {
                          'Content-Type': 'application/json'
                        }
                      }
                    ).then(function (response) {

                      let status = response.data;

                      setStatus(status);

                      console.log(response)
                    })
                      .catch(function (error) {
                        console.log(error)
                      })


                    console.warn(username);

                    setreloadStatus(0);




                  }
                  else //ONLCLICK POST :RETURNS BOOLEAN

                  {

                    axios.post(url, postdata
                      , {
                        headers: {
                          'Content-Type': 'application/json'
                        }
                      }
                    ).then(function (response) {

                      setStatus(true);

                      console.log(response)
                    })
                      .catch(function (error) {
                        console.log(error)
                      })


                    console.warn(username);

                  }





  })
    .catch(function (error) {
      console.log(error)
    })




  }

  useEffect(() => { 
    
    populateuserData(); func() }, []);


  return (
    <>

      <Container fluid="md" >
        <Row className="mt-3">
          <Col lg={9}>
            <Card >
              <Card.Body className='text-center'>
                {forecasts.filter(person =>
                  person.id === val).map(filtereddata => (
                    <div key="{filtereddata}">
                      <video width="1080" controls>

                        <source src={require('../static/videos/' + filtereddata.content_Path).default} type="video/mp4" />
                      </video>

                    </div>
                  ))}

                <Card.Text >
                  {forecasts.filter(person =>
                    person.id === val).map(filtereddata => (
                      <div key="{filtereddata}">
                        <h3>{filtereddata.name}</h3>
                      </div>

                    ))}
                </Card.Text>
              </Card.Body>
            </Card>
          </Col>


          <Col>
            <>


              {
                (is_added === false) ?
                  (<Button onClick={func} className='mb-2 btn-sm btn-primary col-6 mx-auto'> Add to Watchlist </Button>)
                  :
                  (<Button className='mb-2 btn-sm btn-success col-6 mx-auto'> Added to Watchlist </Button>)


              }

            </>



            <Card className='text-center'>



              {forecasts.filter(person =>
                person.id === val).map(filtereddata => (
                  <div key="{filtereddata}">
                    <Card.Header className='text-center'>{filtereddata.name}</Card.Header>
                    <Card.Body>

                      <div >
                        <img src={require('../static/images/' + filtereddata.movie_Poster_Path).default} alt={"demo"} />

                      </div>
                      <Card.Text>{filtereddata.description}</Card.Text>

                    </Card.Body>

                  </div>
                ))}



            </Card>
          </Col>


        </Row>
      </Container>


    </>
  );
}