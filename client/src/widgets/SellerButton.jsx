import { styled } from "@mui/material/styles";
import { Box } from "@mui/material";
import FlexBetween from "components/FlexBetween";
import Typography from "@mui/material/Typography";
import { useTheme } from "@emotion/react";
import UserImage from "components/UserImage";

const StyledBox = styled(Box)({
  border: `1px solid #291e11`,
  padding: "0.1rem",
  width: "16rem",
  borderRadius: 14,
  display: "flex",
});

function SellerButton({ image }) {
  const theme = useTheme();
  const neutralMain = theme.palette.neutral.mediumMain;
  const neutral = theme.palette.neutral.light;
  const neutralDark = theme.palette.neutral.dark;
  const dark = theme.palette.neutral.dark;
  const background = theme.palette.background.default;
  const primaryLight = theme.palette.primary.light;
  const primaryMain = theme.palette.primary.main;
  const alt = theme.palette.background.alt;

  return (
    <StyledBox
      sx={{
        boxShadow: 3,
        "&:hover": {
          backgroundColor: neutralDark,
          cursor: "pointer",
          transitionDuration: "0.4s",
        },
        "&:not(:hover)": {
          backgroundColor: background,
          transitionDuration: "0.4s",
        },
      }}
      gap="1rem"
    >
      <Box
        width="100%"
        display="flex"
        marginRight={"0.4rem"}
        marginTop="0.2rem"
        marginBottom="0.2rem"
      >
        <Box marginLeft={"0.4rem"}>
          <UserImage image={image}></UserImage>
        </Box>
        <Box
          marginLeft={"1rem"}
          display={"flex"}
          flexDirection={"column"}
          justifyContent={"space-evenly"}
        >
          <Typography fontWeight="bold" variant="h4" color="primary">
            Deneme
          </Typography>
          <Typography fontSize={"0.8rem"} color={neutralMain}>
            Company ∙ Computer Vision
          </Typography>
        </Box>
      </Box>
    </StyledBox>
  );
}

export default SellerButton;
