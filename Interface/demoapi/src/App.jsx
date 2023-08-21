import { useEffect, useState } from 'react'
import { getNguoiDungAPI } from './api/NguoiDung/nguoidungclient';

function App() {

  const [nguoiDung, setNguoiDung] = useState([]);

  useEffect(() => {
    fetchData();
  }, []);

const fetchData = async () => {
  setNguoiDung(await getNguoiDungAPI());
};

  return (
    <>
      <div>
        <p className='badge bg-info'>link : {import.meta.env.VITE_BASE_URL_API}</p>
        {/* <p>{fetchData()}</p> */}
        {
          nguoiDung?.map(function (item, key){
            <p>sdlahdla</p>
          })
        }
        
      </div>
    </>
  )
}

export default App
