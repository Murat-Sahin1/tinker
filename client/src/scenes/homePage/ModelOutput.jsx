import { useState } from "react";
import {
  Box,
  Button,
  TextField,
  useMediaQuery,
  Typography,
  useTheme,
} from "@mui/material";
import EditOutlinedIcon from "@mui/icons-material/EditOutlined";
import { Formik } from "formik";
import * as yup from "yup";
import { useNavigate } from "react-router-dom";
import { useDispatch } from "react-redux";

import Dropzone from "react-dropzone";
import FlexBetween from "components/FlexBetween";

import axios from "axios";

const modelSchema = yup.object().shape({
  model: yup.string().required("Required"),
});

const initialValues = {
  model: "",
};

const ModelOutput = () => {
  const { palette } = useTheme();
  const isNonMobile = useMediaQuery("(min-width:600px)");
  const [output, setOutput] = useState("");

  const getModelOutput = async () => {
    try {
    console.log("method")
      const res = await axios.get("http://localhost:5074/api/File");
      setOutput(res.data);
      console.log(res);
    } catch (ex) {
      console.log(ex);
    }
  };

  return (
    <Box>
      <Button
        display="flex"
        sx={{
          m: "2rem 0",
          p: "1rem",
          width: "65%",
          backgroundColor: palette.primary.main,
          color: palette.background.alt,
          "&:hover": { color: palette.primary.main },
        }}
        onClick={()=>{getModelOutput()}}
      >
        GET MODEL OUTPUT
      </Button>
      <Typography margin="1 rem">{output}</Typography>
    </Box>
  );
};

export default ModelOutput;
