import { useState, useEffect } from "react";
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
  modelID: yup.string().required("Required"),
});

const initialValues = {
  modelID: "",
};

const ModelOutput = () => {
  const { palette } = useTheme();
  const isNonMobile = useMediaQuery("(min-width:600px)");
  const [output, setOutput] = useState("");
  var outputSplitted = "";

  const getModelOutput = async (values, onSubmitProps) => {
    const formData = new FormData();
    formData.append("FileName", values.modelID);
    formData.append("InputName", values.modelID);
    try {
      console.log("method");
      const res = await axios.post(
        "http://localhost:5074/api/File/Execute",
        formData
      );
      setOutput(res.data);
      console.log(res);
    } catch (ex) {
      console.log(ex);
    }
  };

  const handleFormSubmit = async (values, onSubmitProps) => {
    console.log(values);
    await getModelOutput(values, onSubmitProps);
  };

  return (
    <Formik
      onSubmit={handleFormSubmit}
      initialValues={initialValues}
      validationSchema={modelSchema}
    >
      {({
        values,
        errors,
        touched,
        handleBlur,
        handleChange,
        handleSubmit,
        setFieldValue,
        resetForm,
      }) => (
        <form onSubmit={handleSubmit}>
          <Box
            display="flex"
            flexDirection={"column"}
            alignContent={"center"}
            justifyContent={"center"}
            alignItems={"center"}
            marginTop={"2rem"}
          >
            <>
              <TextField
                label="ModelID"
                onBlur={handleBlur} // Handles when clicked away
                onChange={handleChange} //Handles when typing
                value={values.modelID}
                name="modelID"
                sx={{ width: "65%", justifyContent: "center" }}
              />
              <Button
                display="flex"
                type="submit"
                sx={{
                  m: "2rem 0",
                  p: "1rem",
                  width: "45%",
                  backgroundColor: palette.primary.main,
                  color: palette.background.alt,
                  "&:hover": { color: palette.primary.main },
                }}
                onClick={() => {
                  getModelOutput();
                }}
              >
                <Typography
                  fontWeight="bold"
                  variant="h5"
                  justifyContent={"center"}
                  alignSelf={"center"}
                >
                  GET MODEL OUTPUT
                </Typography>
              </Button>
              
                {output.split("\n").map((line, index) => (
                  <Typography margin="1 rem">{line}</Typography>
                ))}
              
            </>
          </Box>
        </form>
      )}
    </Formik>
  );
};

export default ModelOutput;
