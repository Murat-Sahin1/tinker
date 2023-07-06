import NavBar from "scenes/navbar";
import { useState, useEffect } from "react";
import { Box, Typography, useTheme, Button, Divider } from "@mui/material";
import CategoryListingButton from "widgets/categoryWidgets/CategoryListingButton";
import ProductListingWidget from "widgets/categoryWidgets/ProductListingWidget";
import FlexBetween from "components/FlexBetween";
import axios from "axios";
import ThumbUpIcon from "@mui/icons-material/ThumbUp";
import IconCard from "widgets/productDetailWidgets/IconCard";
import { useLocation } from "react-router-dom";
import InfoIcon from "@mui/icons-material/Info";
import { Info } from "@mui/icons-material";

const ProductDetailPage = () => {
  const theme = useTheme();
  const neutralMain = theme.palette.neutral.mediumMain;
  const neutralLight = theme.palette.neutral.light;
  const neutralDark = theme.palette.neutral.dark;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  const location = useLocation();
  const { product } = location.state;

  const [selectedButton, setSelectedButton] = useState(1);
  const [evaluationMetrics, setEvaluationMetrics] = useState();
  const [isLoading, setIsLoading] = useState(true);

  const getEvaluationMetrics = async (modelId) => {
    console.log(modelId);
    try {
      await axios
        .get(`https://localhost:7260/api/File/evaluation/${modelId}`)
        .then((response) => {
          setEvaluationMetrics(response.data);
          setIsLoading(false);
        });
    } catch (ex) {
      console.log("Error while requesting evaluation.");
      console.log(ex);
    }
  };

  useEffect(() => {
    getEvaluationMetrics(product.modelID);
  }, []);

  const handleButtonClick = (buttonId) => {
    setSelectedButton(buttonId);
    console.log(evaluationMetrics);
  };

  return (
    <Box>
      {isLoading ? null : (
        <Box>
          <NavBar />
          {/* Container */}
          <Box
            width="100%"
            paddingY="1px"
            justifyContent={"center"}
            display="flex"
          >
            {/* Alt Color */}
            <Box
              width="100%"
              alignItems={"center"}
              display="flex"
              backgroundColor={alt}
            >
              {/* Header Part */}
              <Box
                marginLeft={"13%"}
                p="1rem"
                display="flex"
                flexDirection={"column"}
                justifyContent={"flex-start"}
              >
                {/* Model Name */}
                <Box
                  gap="1rem"
                  alignSelf="flex-start"
                  padding="1rem"
                  marginBottom={"0.3rem"}
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                >
                  <img
                    style={{ objectFit: "cover" }}
                    width={"60px"}
                    height={"60px"}
                    alt="user"
                    src="https://images.emojiterra.com/twitter/v13.1/512px/1f916.png"
                  />
                  <Box>
                    <Typography fontSize={"2rem"} fontWeight={"bold"} color="">
                      {product.name}
                    </Typography>
                    <Typography fontSize={"0.9rem"} color={primaryMain}>
                      by FinlandSoftware
                    </Typography>
                  </Box>

                  <Box
                    display="flex"
                    textAlign={"center"}
                    alignItems={"center"}
                    justifyContent={"center"}
                  >
                    <ThumbUpIcon />
                    <Typography paddingLeft={"5px"}>234</Typography>
                  </Box>
                </Box>

                {/* Icons */}
                <Box display="flex" gap="0.3rem">
                  <IconCard text="Image Transformer" />
                  <IconCard text="Top Rated" />
                  <IconCard text="Recommended" />
                  <IconCard text="Image Transformer" />
                  <IconCard text="Image Transformer" />
                </Box>
              </Box>
              <Box
                width="13%"
                display="flex"
                marginLeft="1%"
                alignItems={"center"}
                justifyContent={"center"}
                flexDirection={"column"}
              >
                <Button
                  style={{ textTransform: "none", padding: "0.5rem 2.3rem" }}
                  width="100%"
                  variant="contained"
                >
                  <Typography fontSize="1.3rem">BUY</Typography>
                </Button>
                <Typography
                  paddingTop={"5px"}
                  color={neutralDark}
                  sx={{
                    whiteSpace: "pre-line",
                    opacity: 0.7,
                  }}
                >
                  Sold: {product.sold}
                </Typography>
              </Box>
            </Box>
          </Box>
          {/* File Buttons */}
          <Box paddingTop="1rem" paddingLeft="6rem" width="60%">
            <Box paddingX="2rem" display="flex" gap="2rem">
              <Box
                onClick={() => handleButtonClick(1)}
                marginLeft={"2rem"}
                width="10rem"
                height="4rem"
                sx={{
                  backgroundColor:
                    selectedButton === 1 ? neutralDark : background,
                  "& .text": {
                    color: selectedButton === 1 ? background : neutralDark,
                  },
                  transitionDuration: "0.4s",
                  "&:hover": {
                    backgroundColor: neutralDark,
                    cursor: "pointer",
                    transitionDuration: "0.4s",
                    "& .text": {
                      color: background,
                      transitionDuration: "0.4s",
                    },
                  },
                  borderRadius: "10px 10px 0 0",
                  borderRight: `2px ${alt} solid`,
                  borderTop: `2px ${alt} solid`,
                  borderLeft: `2px ${alt} solid`,
                  boxShadow: 3,
                }}
                justifyContent={"center"}
                alignItems={"center"}
                display="flex"
              >
                <Typography className="text" fontSize="1.2rem">
                  Information
                </Typography>
              </Box>
              <Box
                onClick={() => handleButtonClick(2)}
                width="10rem"
                height="4rem"
                sx={{
                  backgroundColor:
                    selectedButton === 2 ? neutralDark : background,
                  "& .text": {
                    color: selectedButton === 2 ? background : neutralDark,
                  },
                  transitionDuration: "0.4s",
                  "&:hover": {
                    backgroundColor: neutralDark,
                    cursor: "pointer",
                    transitionDuration: "0.4s",
                    "& .text": {
                      color: background,
                      transitionDuration: "0.4s",
                    },
                  },
                  borderRadius: "10px 10px 0 0",
                  borderRight: `2px ${alt} solid`,
                  borderTop: `2px ${alt} solid`,
                  borderLeft: `2px ${alt} solid`,
                  boxShadow: 3,
                }}
                justifyContent={"center"}
                alignItems={"center"}
                display="flex"
              >
                <Typography className="text" fontSize="1.2rem">
                  Performance
                </Typography>
              </Box>
              <Box
                onClick={() => handleButtonClick(3)}
                width="10rem"
                height="4rem"
                sx={{
                  backgroundColor:
                    selectedButton === 3 ? neutralDark : background,
                  "& .text": {
                    color: selectedButton === 3 ? background : neutralDark,
                  },
                  transitionDuration: "0.4s",
                  "&:hover": {
                    backgroundColor: neutralDark,
                    cursor: "pointer",
                    transitionDuration: "0.4s",
                    "& .text": {
                      color: background,
                      transitionDuration: "0.4s",
                    },
                  },
                  borderRadius: "10px 10px 0 0",
                  borderRight: `2px ${alt} solid`,
                  borderTop: `2px ${alt} solid`,
                  borderLeft: `2px ${alt} solid`,
                  boxShadow: 3,
                }}
                justifyContent={"center"}
                alignItems={"center"}
                display="flex"
              >
                <Typography className="text" fontSize="1.2rem">
                  Seller
                </Typography>
              </Box>
              <Box
                onClick={() => handleButtonClick(4)}
                width="13rem"
                height="4rem"
                sx={{
                  backgroundColor:
                    selectedButton === 4 ? neutralDark : background,
                  "& .text": {
                    color: selectedButton === 4 ? background : neutralDark,
                  },
                  transitionDuration: "0.4s",
                  "&:hover": {
                    backgroundColor: neutralDark,
                    cursor: "pointer",
                    transitionDuration: "0.4s",
                    "& .text": {
                      color: background,
                      transitionDuration: "0.4s",
                    },
                  },
                  borderRadius: "10px 10px 0 0",
                  borderRight: `2px ${alt} solid`,
                  borderTop: `2px ${alt} solid`,
                  borderLeft: `2px ${alt} solid`,
                  boxShadow: 3,
                }}
                justifyContent={"center"}
                alignItems={"center"}
                display="flex"
                marginLeft={"10%"}
              >
                <Typography className="text" fontSize="1.2rem">
                  Test
                </Typography>
              </Box>
              <Box
                onClick={() => handleButtonClick(5)}
                width="13rem"
                height="4rem"
                sx={{
                  backgroundColor:
                    selectedButton === 5 ? neutralDark : background,
                  "& .text": {
                    color: selectedButton === 5 ? background : neutralDark,
                  },
                  transitionDuration: "0.4s",
                  "&:hover": {
                    backgroundColor: neutralDark,
                    cursor: "pointer",
                    transitionDuration: "0.4s",
                    "& .text": {
                      color: background,
                      transitionDuration: "0.4s",
                    },
                  },
                  borderRadius: "10px 10px 0 0",
                  borderRight: `2px ${alt} solid`,
                  borderTop: `2px ${alt} solid`,
                  borderLeft: `2px ${alt} solid`,
                  boxShadow: 3,
                }}
                justifyContent={"center"}
                alignItems={"center"}
                display="flex"
              >
                <Typography className="text" fontSize="1.2rem">
                  Comments
                </Typography>
              </Box>
            </Box>
          </Box>
          {/* Detail Page */}
          <Box display="flex" gap="1rem">
            <Box paddingLeft="6rem" width="70%">
              <Box paddingX="2rem" display="flex">
                <Box
                  width="100%"
                  height="36rem"
                  backgroundColor={alt}
                  borderRadius={2}
                  display="flex"
                  flexDirection={"column"}
                  boxShadow={5}
                  justifyContent={"flex-start"}
                  alignItems={"flex-start"}
                >
                  {selectedButton === 1 && (
                    <Box paddingLeft={"6rem"} paddingTop="1rem">
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h1"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        {product.name}
                      </Typography>
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        {product.description}
                      </Typography>
                    </Box>
                  )}
                  {selectedButton === 2 && (
                    <Box paddingLeft={"6rem"} paddingTop="1rem">
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h1"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Performance
                      </Typography>
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h4"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Precision Array:
                      </Typography>
                      <Box>
                      {evaluationMetrics.precision.map((item, index) => (
                        <Typography
                          key={index}
                          fontWeight="bold"
                          marginTop="1rem"
                          color="primary"
                          sx={{
                            lineHeight: 1.2,
                            whiteSpace: "pre-line",
                          }}
                        >
                          {index}{": "}{item}{" "}
                        </Typography>
                      ))}
                      </Box>
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h4"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Recall Array:
                      </Typography>
                      <Box>
                      {evaluationMetrics.recall.map((item, index) => (
                        <Typography
                          key={index}
                          fontWeight="bold"
                          marginTop="1rem"
                          color="primary"
                          sx={{
                            lineHeight: 1.2,
                            whiteSpace: "pre-line",
                          }}
                        >
                          {index}{": "}{item}{" "}
                        </Typography>
                      ))}
                      </Box>
                    </Box>
                  )}
                  {selectedButton === 3 && (
                    <Box paddingLeft={"6rem"} paddingTop="1rem">
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h1"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Seller information
                      </Typography>
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        This model sold: {product.sold}
                      </Typography>
                    </Box>
                  )}
                  {selectedButton === 4 && (
                    <Box paddingLeft={"6rem"} paddingTop="1rem">
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h1"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Test this model
                      </Typography>
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Go ahead and do your own tests, but remember; test count
                        is limited to 5.
                      </Typography>
                    </Box>
                  )}
                  {selectedButton === 5 && (
                    <Box paddingLeft={"6rem"} paddingTop="1rem">
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        variant="h1"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Comment Section
                      </Typography>
                      <Typography
                        fontWeight="bold"
                        marginTop="1rem"
                        color="primary"
                        sx={{
                          lineHeight: 1.2,
                          whiteSpace: "pre-line",
                        }}
                      >
                        Comments here
                      </Typography>
                    </Box>
                  )}
                </Box>
              </Box>
            </Box>

            <Box
              width="25%"
              backgroundColor={alt}
              borderRadius={2}
              boxShadow={5}
            >
              <Box display="flex" justifyContent="center" alignItems={"center"}>
                <Typography
                  variant="h2"
                  paddingTop={"1rem"}
                  fontWeight={"bold"}
                >
                  Metrics
                </Typography>
              </Box>
              <Box paddingX="2rem">
                <Divider />
              </Box>
              <Box
                display="flex"
                padding="1rem"
                justifyContent={"space-evenly"}
              >
                <Box
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                  flexDirection={"column"}
                  width={"20%"}
                >
                  <InfoIcon />
                  <Typography variant="h4">Accuracy</Typography>
                  <Box>{evaluationMetrics.accuracy}</Box>
                </Box>
                <Box
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                  flexDirection={"column"}
                  width={"20%"}
                >
                  <InfoIcon />
                  <Typography variant="h4">Rmse</Typography>
                  <Box>{evaluationMetrics.rmse}</Box>
                </Box>
              </Box>
              <Box
                display="flex"
                padding="1rem"
                justifyContent={"space-evenly"}
              >
                <Box
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                  flexDirection={"column"}
                  width={"20%"}
                >
                  <InfoIcon />
                  <Typography variant="h4">Mae</Typography>
                  <Box>{evaluationMetrics.mae}</Box>
                </Box>
                <Box
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                  flexDirection={"column"}
                  width={"20%"}
                >
                  <InfoIcon />
                  <Typography variant="h4">Accuracy</Typography>
                  <Box>8.3</Box>
                </Box>
              </Box>
              <Box
                display="flex"
                padding="1rem"
                justifyContent={"space-evenly"}
              >
                <Box
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                  flexDirection={"column"}
                  width={"20%"}
                >
                  <InfoIcon />
                  <Typography variant="h4">Accuracy</Typography>
                  <Box>8.3</Box>
                </Box>
                <Box
                  display="flex"
                  justifyContent={"center"}
                  alignItems={"center"}
                  flexDirection={"column"}
                  width={"20%"}
                >
                  <InfoIcon />
                  <Typography variant="h4">Accuracy</Typography>
                  <Box>8.3</Box>
                </Box>
              </Box>
              <Box
                display="flex"
                padding="0.5rem"
                paddingX="3rem"
                paddingjustifyContent={"space-evenly"}
              >
                <Box width="%100">
                  <Box
                    display="flex"
                    flexDirection={"column"}
                    alignItems={"center"}
                    textAlign={"center"}
                  >
                    <InfoIcon />
                    <Typography variant="h4">Disclaimer</Typography>
                    <p
                      style={{
                        lineHeight: 1.6,
                        fontSize: 15,
                        fontStyle: "italic",
                        textDecoration: "underline",
                      }}
                    >
                      The metrics given above are calculated by the information
                      that the model creator provided.
                    </p>
                  </Box>
                </Box>
              </Box>
            </Box>
          </Box>
        </Box>
      )}
    </Box>
  );
};

export default ProductDetailPage;
